from django.contrib import admin
from .models import InformacionJano, RedesSocialesJano

# Register your models here.
class InformacionJanoAdmin(admin.ModelAdmin):
    list_display = ("id", "ultima_actualizacion", "estado")
    search_fields = ("estado", "frase", "ultima_actualizacion")
    fields=("icono", "portada", "frase", "texto", "imagen", "ultima_actualizacion", "estado")
    readonly_fields = ("ultima_actualizacion",)

admin.site.register(InformacionJano, InformacionJanoAdmin)

class RedesSocialesJanoAdmin(admin.ModelAdmin):
    list_display = ('nombre_red_social', 'enlace_red_social', 'estado')
    list_filter = ('estado',)
    search_fields = ('nombre_red_social', 'enlace_red_social')
    fields=("nombre_red_social", "enlace_red_social", "imagen_fondo_red_social", "icono_red_social", "estado")

admin.site.register(RedesSocialesJano, RedesSocialesJanoAdmin)