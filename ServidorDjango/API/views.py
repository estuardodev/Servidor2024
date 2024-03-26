from django.shortcuts import render
import json
import datetime
from django.http import HttpResponse, HttpResponseBadRequest
from django.template.loader import render_to_string
from weasyprint import HTML
from weasyprint.document import FontConfiguration
from django.views.decorators.csrf import csrf_exempt

# Create your views here.

@csrf_exempt
def export_pdf(request):
    context = {}
    if request.body and request.method == "POST":
        try:
            body = request.body
            data = json.loads(body)
            key_to_remove:list = []
            for key in data:
                if data[key] == None:
                    key_to_remove.append(key)
            
            for key in key_to_remove:
                del data[key]

            persepction:list = [value for value in data["extraPerceptions"] if value is not None]
            data["extraPerceptions"] = persepction

            persepction:list = [value for value in data["extraDeductions"] if value is not None]
            data["extraDeductions"] = persepction

            context["data"] = data

            persepctions:list = data["perceptions"]
            persepctions = persepctions.split(",")
            bonos:list = [i.split("$") for i in persepctions]
            context["perceptions"] = bonos
        except Exception as e:
            print(e)

        hora_actual = datetime.datetime.now()

        hora_am_pm = hora_actual.strftime("%I:%M %p")
        context['hour_am_pm'] = hora_am_pm

        html = render_to_string("app/report.html", context)
        response = HttpResponse(content_type="application/pdf")
        response["Content-Disposition"] = "inline; report.pdf"
        font_config = FontConfiguration()
        HTML(string=html, base_url=request.build_absolute_uri()).write_pdf(response, font_config=font_config)

        return response
    else:
        return HttpResponseBadRequest("No data found")

