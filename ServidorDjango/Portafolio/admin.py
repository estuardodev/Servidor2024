from django.contrib import admin
from .models import Portafolio, Habilidades, Certificaciones, Proyectos, FormularioContacto
from .models import IdentificadorEmail, Emails, EmailsEnviados
# Register your models here.
admin.site.site_header = 'estuardodev'
admin.site.index_title = 'Panel de control de mi sitio'
admin.site.site_title = 'Administrador'

class PortafolioAdmin(admin.ModelAdmin):
    list_display = ('__str__',)
    fields = ('imagen', 'texto_largo')

admin.site.register(Portafolio, PortafolioAdmin)

class HabilidadesAdmin(admin.ModelAdmin):
    list_display = ('descHabilidad',)
    fields = ('descHabilidad',)

admin.site.register(Habilidades, HabilidadesAdmin)

class CertificacionesAdmin(admin.ModelAdmin):
    list_display = ('titulo',)
    fields = ('titulo', 'descripcion', 'enlace', 'imagen')

admin.site.register(Certificaciones, CertificacionesAdmin)

class ProyectosAdmin(admin.ModelAdmin):
    list_display = ('titulo',)
    fields = ('titulo', 'descripcion', 'texto_enlace', 'enlace', 'imagen', 'alt_imagen')

admin.site.register(Proyectos, ProyectosAdmin)

class FormularioContactoAdmin(admin.ModelAdmin):
    list_display = ('nombre', 'correo', 'fecha', 'terminos', 'es_spam')
    list_filter = ('nombre', 'correo', 'fecha')
    search_fields = ('nombre', 'correo', 'fecha')
    readonly_fields = ('nombre', 'correo', 'fecha','mensaje', 'terminos')
    ordering = ('-id',)

admin.site.register(FormularioContacto, FormularioContactoAdmin)    


@admin.register(IdentificadorEmail)
class IdentificadorEmailAdmin(admin.ModelAdmin):
    list_display = ('identificador', 'estado')
    search_fields = ['identificador']

@admin.register(Emails)
class EmailsAdmin(admin.ModelAdmin):
    list_display = ('email_address', 'subscribe_to_newsletter')
    search_fields = ['email_address']

@admin.register(EmailsEnviados)
class EmailsEnviadosAdmin(admin.ModelAdmin):
    list_display = ('_from', '_to', '_subject', '_datetime')
    search_fields = ['_from', '_to']