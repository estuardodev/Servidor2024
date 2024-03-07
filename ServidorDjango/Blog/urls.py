from django.urls import path

from . import views

urlpatterns = [
    path('getImage', views.getImage, name='getImage'),
]