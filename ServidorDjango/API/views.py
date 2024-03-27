import json
import datetime
from django.http import HttpResponse, HttpResponseBadRequest
from django.template.loader import render_to_string
from weasyprint import HTML
from weasyprint.document import FontConfiguration
from django.views.decorators.csrf import csrf_exempt
from django.conf import settings

# Create your views here.
authorization = settings.AUTHORIZATION

@csrf_exempt
def export_pdf(request):
    if request.headers.get("Authorization") != authorization:
        return HttpResponseBadRequest("Unauthorized")
    
    if not request.body and request.method != "POST":
        return HttpResponseBadRequest("No data found")
    
    context = {}
    try:
        body = request.body
        data = json.loads(body)
        data = {key: value for key, value in data.items() if value is not None}

        persepction:list = [value for value in data["extraPerceptions"] if value is not None]
        data["extraPerceptions"] = persepction

        persepction:list = [value for value in data["extraDeductions"] if value is not None]
        data["extraDeductions"] = persepction
        context["data"] = data
    
        persepctions:list = data["perceptions"]
        persepctions:list = persepctions.split(",")
        bonos:list = [i.split("$") for i in persepctions]
        data["perceptions"] = bonos
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
   

