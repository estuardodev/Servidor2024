# Generated by Django 5.0.2 on 2024-02-22 23:23

import tinymce.models
from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='CookiesModel',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('nombre_propietario', models.CharField(max_length=40, verbose_name='Nombre del Propietario')),
                ('nombre_de_usuario', models.CharField(max_length=25, verbose_name='Nombre de usuario')),
                ('contenido', tinymce.models.HTMLField(max_length=30000, verbose_name='Políticas de Cookies')),
                ('ultima_actualizacion', models.DateTimeField(auto_now=True, verbose_name='Última Actualización')),
                ('estado', models.BooleanField(default=False, verbose_name='Estado de la Cookies')),
            ],
            options={
                'verbose_name': 'Cookies',
                'verbose_name_plural': 'Cookies',
                'db_table': 'Cookies',
            },
        ),
        migrations.CreateModel(
            name='PoliticasModel',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('nombre_propietario', models.CharField(max_length=40, verbose_name='Nombre del Propietario')),
                ('nombre_de_usuario', models.CharField(max_length=25, verbose_name='Nombre de usuario')),
                ('contenido', tinymce.models.HTMLField(max_length=30000, verbose_name='Políticas de Privacidad')),
                ('ultima_actualizacion', models.DateTimeField(auto_now=True, verbose_name='Última Actualización')),
                ('estado', models.BooleanField(default=False, verbose_name='Estado de la política')),
            ],
            options={
                'verbose_name': 'Política de Privacidad',
                'verbose_name_plural': 'Políticas de Privacidad',
                'db_table': 'Privacidad',
            },
        ),
        migrations.CreateModel(
            name='TerminosModel',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('nombre_propietario', models.CharField(max_length=40, verbose_name='Nombre del Propietario')),
                ('nombre_de_usuario', models.CharField(max_length=25, verbose_name='Nombre de usuario')),
                ('contenido', tinymce.models.HTMLField(max_length=30000, verbose_name='Términos y Condiciones')),
                ('ultima_actualizacion', models.DateTimeField(auto_now=True, verbose_name='Última Actualización')),
                ('estado', models.BooleanField(default=False, verbose_name='Estado de los términos')),
            ],
            options={
                'verbose_name': 'Términos y Condiciones',
                'verbose_name_plural': 'Términos y Condiciones',
                'db_table': 'Terminos',
            },
        ),
    ]