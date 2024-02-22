from django.db import models
from tinymce.models import HTMLField

# Create your models here.
class PoliticasModel(models.Model):
    nombre_propietario = models.CharField(verbose_name="Nombre del Propietario", max_length=40, null=False)
    nombre_de_usuario = models.CharField(verbose_name="Nombre de usuario", max_length=25, null=False)
    contenido = HTMLField(verbose_name="Políticas de Privacidad",max_length=30000)
    ultima_actualizacion = models.DateTimeField(verbose_name="Última Actualización", auto_now=True)
    estado = models.BooleanField(verbose_name="Estado de la política", default=False)

    class Meta:
        db_table = "Privacidad"
        verbose_name = "Política de Privacidad"
        verbose_name_plural = "Políticas de Privacidad"

    def __str__(self) -> str:
        return f"Política de Privacidad actualizada el {str(self.ultima_actualizacion)}"
    

class TerminosModel(models.Model):
    nombre_propietario = models.CharField(verbose_name="Nombre del Propietario", max_length=40, null=False)
    nombre_de_usuario = models.CharField(verbose_name="Nombre de usuario", max_length=25, null=False)
    contenido = HTMLField(verbose_name="Términos y Condiciones",max_length=30000)
    ultima_actualizacion = models.DateTimeField(verbose_name="Última Actualización", auto_now=True)
    estado = models.BooleanField(verbose_name="Estado de los términos", default=False)

    class Meta:
        db_table = "Terminos"
        verbose_name = "Términos y Condiciones"
        verbose_name_plural = "Términos y Condiciones"

    def __str__(self) -> str:
        return f"Términos y Condiciones actualizada el {str(self.ultima_actualizacion)}"
    

class CookiesModel(models.Model):
    nombre_propietario = models.CharField(verbose_name="Nombre del Propietario", max_length=40, null=False)
    nombre_de_usuario = models.CharField(verbose_name="Nombre de usuario", max_length=25, null=False)
    contenido = HTMLField(verbose_name="Políticas de Cookies",max_length=30000)
    ultima_actualizacion = models.DateTimeField(verbose_name="Última Actualización", auto_now=True)
    estado = models.BooleanField(verbose_name="Estado de la Cookies", default=False)

    class Meta:
        db_table = "Cookies"
        verbose_name = "Cookies"
        verbose_name_plural = "Cookies"

    def __str__(self) -> str:
        return f"Cookies actualizada el {str(self.ultima_actualizacion)}"    
    