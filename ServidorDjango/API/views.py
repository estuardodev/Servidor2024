import json
from django.http import HttpResponse, HttpResponseBadRequest
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
def export_pdf(request):
    context = {}
    if request.method != "POST" or not request.body:
        return HttpResponseBadRequest("Bad Request")

    try:
        body = request.body
        data = json.loads(body)
        data = ConvertToListDict(data)
            

        print(data[1]["kitchenDeduction"])
        for index in range(len(data)):

            if data[index]["extraPerceptions"] != None:
                extraPerceptions:list = [value for value in data[index]["extraPerceptions"] if value is not None and value != ""]
                data[index]["extraPerceptions"] = extraPerceptions

            if data[index]["extraPerceptions"] != None:
                extraDeductions:list = [value for value in data[index]["extraDeductions"] if value is not None and value != ""]
                data[index]["extraDeductions"] = extraDeductions

            if data[index]["kitchenDeduction"] != None:
                kitchenDeduction:list = [value for value in data[index]["kitchenDeduction"] if value is not None and value != ""]
                data[index]["kitchenDeduction"] = kitchenDeduction
            
            persepctions:list = data[index]["perceptions"].split(",")
            bonos:list = [i.split("$") for i in persepctions]
            data[index]["perceptions"] = bonos

    

        context["datas"] = data

        html = render_to_string("app/report.html", context)
        response = HttpResponse(content_type="application/pdf")
        response["Content-Disposition"] = "inline; report.pdf"
        font_config = FontConfiguration()
        HTML(string=html, base_url=request.build_absolute_uri()).write_pdf(response, font_config=font_config)

        return response
    except Exception as e:
        print(e)
        return HttpResponseBadRequest("Bad Request")