# Generated by Django 5.0.2 on 2024-02-22 23:23

import django_resized.forms
import tinymce.models
from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='InformacionJano',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('icono', django_resized.forms.ResizedImageField(crop=None, force_format='WEBP', keep_meta=True, quality=100, scale=None, size=[1920, 1080], upload_to='imagenes_jano/', verbose_name='Portada (512x512)')),
                ('portada', django_resized.forms.ResizedImageField(crop=None, force_format='WEBP', keep_meta=True, null=True, quality=100, scale=None, size=[1920, 1080], upload_to='imagenes_jano/', verbose_name='Portada (1920x828)')),
                ('frase', models.CharField(blank=True, max_length=150, verbose_name='Frase')),
                ('texto', tinymce.models.HTMLField(blank=True, max_length=5000, null=True, verbose_name='Contenido')),
                ('imagen', django_resized.forms.ResizedImageField(crop=None, force_format='WEBP', keep_meta=True, quality=100, scale=None, size=[1920, 1080], upload_to='imagenes_jano/')),
                ('ultima_actualizacion', models.DateTimeField(auto_now=True, verbose_name='Última actualización')),
                ('estado', models.BooleanField(default=False, verbose_name='Estado')),
            ],
            options={
                'verbose_name': 'Contenido de Jano Abonce',
                'verbose_name_plural': 'Contenido de Jano Abonce',
                'db_table': 'InformacionJano',
            },
        ),
        migrations.CreateModel(
            name='RedesSocialesJano',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('nombre_red_social', models.CharField(blank=True, max_length=50, null=True, verbose_name='Nombre de la Red Social')),
                ('enlace_red_social', models.CharField(max_length=75, verbose_name='Enlace de la Red Social')),
                ('imagen_fondo_red_social', django_resized.forms.ResizedImageField(crop=None, force_format='WEBP', keep_meta=True, quality=100, scale=None, size=[1920, 1080], upload_to='imagenes_jano/', verbose_name='Imágen de fondo')),
                ('icono_red_social', django_resized.forms.ResizedImageField(crop=None, force_format='WEBP', keep_meta=True, quality=100, scale=None, size=[1920, 1080], upload_to='imagenes_jano/', verbose_name='Icono de la red social (NO SVG)')),
                ('estado', models.BooleanField(default=False, verbose_name='Estado')),
            ],
            options={
                'verbose_name': 'Redes Sociales de Jano Abonce',
                'verbose_name_plural': 'Redes Sociales de Jano Abonce',
                'db_table': 'RedesSocialesJano',
            },
        ),
    ]
