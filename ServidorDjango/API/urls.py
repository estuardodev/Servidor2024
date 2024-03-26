from django.urls import path
from . import views

urlpatterns = [
    path('report-pdf/', views.export_pdf, name="report"),
]