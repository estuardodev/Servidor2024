import json
from django.http import HttpResponse, HttpResponseBadRequest, HttpResponseServerError
from django.template.loader import render_to_string
from weasyprint import HTML
from weasyprint.document import FontConfiguration
from django.views.decorators.csrf import csrf_exempt

# Create your views here.
def ConvertToListDict(data) -> list:
    datos = []
    for index in range(len(data)):
        dic = {}
        for key, value in data[index].items():
            dic[key] = value
        datos.append(dic)
    return datos

@csrf_exempt
async def export_pdf(request):
    context:dict = {}
    if request.method != "POST" or not request.body:
        return HttpResponseBadRequest("Bad Request")

    try:
        body = request.body
        data = json.loads(body)
        data:list = ConvertToListDict(data)
        
        for index in range(len(data)):
            if "extraPerceptions" in data[index]:
                if data[index]["extraPerceptions"] != None:
                    extraPerceptions:list = [value for value in data[index]["extraPerceptions"] if value is not None and value != ""]
                    data[index]["extraPerceptions"] = extraPerceptions

            if "extraDeductions" in data[index]:
                if data[index]["extraDeductions"] != None:
                    extraDeductions:list = [value for value in data[index]["extraDeductions"] if value is not None and value != ""]
                    data[index]["extraDeductions"] = extraDeductions

            if "kitchenDeduction" in data[index]:
                if data[index]["kitchenDeduction"] != None:
                    kitchenDeduction:list = [value for value in data[index]["kitchenDeduction"] if value is not None and value != ""]
                    data[index]["kitchenDeduction"] = kitchenDeduction
            
            if "perceptions" in data[index]:
                persepctions:list = data[index]["perceptions"].split(",")
                bonos:list = [i.split("$") for i in persepctions]
                data[index]["perceptions"] = bonos
        context["counter"] = 0
        context["datas"] = data
        html:str = render_to_string("app/report.html", context)
        response = HttpResponse(content_type="application/pdf")
        response["Content-Disposition"] = "inline; report.pdf"
        font_config = FontConfiguration()
        HTML(string=html, base_url=request.build_absolute_uri()).write_pdf(response, font_config=font_config)

        return response
    except KeyError as e:
        template_name = render_to_string("app/error.html", {"error": e})
        return HttpResponseServerError(template_name)