# Generated by Django 5.0.3 on 2024-06-03 00:49

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('Blog', '0003_remove_articulo_ip_likes'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='articulo',
            name='autor',
        ),
        migrations.RemoveField(
            model_name='articulo',
            name='categorias',
        ),
        migrations.RemoveField(
            model_name='articulo',
            name='estado',
        ),
        migrations.DeleteModel(
            name='Autores',
        ),
        migrations.DeleteModel(
            name='Categoria',
        ),
        migrations.DeleteModel(
            name='Articulo',
        ),
        migrations.DeleteModel(
            name='EstadoArticulos',
        ),
    ]
