import json
import datetime
from django.http import HttpResponse, HttpResponseBadRequest
from django.template.loader import render_to_string
from weasyprint import HTML
from weasyprint.document import FontConfiguration
from django.views.decorators.csrf import csrf_exempt
from django.conf import settings

# Create your views here.

@csrf_exempt
def export_pdf(request):
    context = {}

    if request.body and request.method == "POST":
        try:
            body = request.body
            data = json.loads(body)
            
            datos = []
            for index in range(len(data)):
                dic = {}
                for key, value in data[index].items():
                    dic[key] = value
                datos.append(dic)

            data = datos

            
            for index in range(len(data)):
                extraPerceptions:list = [value for value in data[index]["extraPerceptions"] if value is not None]
                data[index]["extraPerceptions"] = extraPerceptions

                extraDeductions:list = [value for value in data[index]["extraDeductions"] if value is not None]
                data[index]["extraDeductions"] = extraDeductions

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
            return HttpResponseBadRequest("Error")
        


#data = {key: value for key, value in data.items() if value is not None}

            

            

            #context["data"] = data

            