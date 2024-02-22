from django.contrib import admin
from . import models

# Register your models here.
class ArticuloAdmin(admin.ModelAdmin):
    list_display = ('titulo', 'fecha_hora_creacion', 'estado')
    search_fields = ('titulo', 'fecha_hora_creacion', 'autor', 'visitas') 
    readonly_fields = ('visitas', 'likes',)
    fields = ('titulo', 'visitas', 'likes', 'descripcion', 'tags', 'url', 'prioridad', 'contenido', 'image', 'descripcion_imagen', 'autor', 'estado', 'categorias')

admin.site.register(models.Articulo, ArticuloAdmin)

class CategoriaAdmin(admin.ModelAdmin):
    list_display = ('nombre',)
    search_fields = ('nombre',)

admin.site.register(models.Categoria, CategoriaAdmin)

class EstadoArticulosAdmin(admin.ModelAdmin):
    list_display = ('__str__', 'estado')
    search_fields = ('estado',)

admin.site.register(models.EstadoArticulos, EstadoArticulosAdmin)

class AutoresAdmin(admin.ModelAdmin):
    list_display = ('nombre_autor', )
    search_fields = ('nombre_autor',)

admin.site.register(models.Autores, AutoresAdmin)
