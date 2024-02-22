from django.contrib import admin
from .models import PoliticasModel, TerminosModel, CookiesModel

# Register your models here.
class PoliticasAdmin(admin.ModelAdmin):
    fields = ("nombre_propietario", "nombre_de_usuario", "contenido", "ultima_actualizacion", "estado")
    readonly_fields = ("ultima_actualizacion",)
    list_display = ("__str__",)

admin.site.register(PoliticasModel, PoliticasAdmin)

class TerminosAdmin(admin.ModelAdmin):
    fields = ("nombre_propietario", "nombre_de_usuario", "contenido", "ultima_actualizacion", "estado")
    readonly_fields = ("ultima_actualizacion",)
    list_display = ("__str__",)

admin.site.register(TerminosModel, TerminosAdmin)

class CookiesAdmin(admin.ModelAdmin):
    fields = ("nombre_propietario", "nombre_de_usuario", "contenido", "ultima_actualizacion", "estado")
    readonly_fields = ("ultima_actualizacion",)
    list_display = ("__str__",)

admin.site.register(CookiesModel, CookiesAdmin)