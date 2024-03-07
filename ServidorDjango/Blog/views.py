import os
from django.shortcuts import render
from django.http import HttpResponseBadRequest, HttpResponse
from django.conf import settings
from io import BytesIO
from PIL import Image

# Create your views here.
DEBUG = settings.DEBUG
if DEBUG:
    STATIC_DIR = os.path.join(settings.SHARE_DIR, 'ServidorASP','bin', 'Release', 'net8.0', 'publish', 'wwwroot',)
else:
    STATIC_DIR = os.path.join(settings.SHARE_DIR, 'ServidorASP', 'wwwroot')
MEDIA_ROOT = settings.MEDIA_ROOT

def getImage(request):
    image_file = request.GET.get('image')
    size = request.GET.get('size')
    format = request.GET.get('format')

    if not image_file:
        return HttpResponseBadRequest('No se ha especificado una imagen')
    
    image_path = f'{MEDIA_ROOT}/{image_file}'
    if not os.path.exists(image_path):
        print(image_path)
        return HttpResponseBadRequest('La imagen no existe')
    
    image = Image.open(image_path)
    if size:
        size = int(size)
        image.thumbnail((size, size))

    if format:
        format = format.lower()
        if format not in ('jpeg', 'png', 'webp'):
            return HttpResponseBadRequest('Formato no válido')
        
        image_format = BytesIO()
        image.save(image_format, format=format.upper())
        return HttpResponse(image_format.getvalue(), content_type=f'image/{format}')
    
    image_io = BytesIO()
    image.save(image_io, format=image.format)
    return HttpResponse(image_io.getvalue(), content_type=f'image/{image.format.lower()}')

def getStatic(request):
    image_file = request.GET.get('image')
    size = request.GET.get('size')
    format = request.GET.get('format')

    if not image_file:
        return HttpResponseBadRequest('No se ha especificado una imagen')
    
    image_path = f'{STATIC_DIR}/{image_file}'
    if not os.path.exists(image_path):
        print(image_path)
        return HttpResponseBadRequest('La imagen no existe')
    
    image = Image.open(image_path)
    if size:
        size = int(size)
        image.thumbnail((size, size))

    if format:
        format = format.lower()
        if format not in ('jpeg', 'png', 'webp'):
            return HttpResponseBadRequest('Formato no válido')
        
        image_format = BytesIO()
        image.save(image_format, format=format.upper())
        return HttpResponse(image_format.getvalue(), content_type=f'image/{format}')
    
    image_io = BytesIO()
    image.save(image_io, format=image.format)
    return HttpResponse(image_io.getvalue(), content_type=f'image/{image.format.lower()}')