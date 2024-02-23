from django.db import models
from django_resized import ResizedImageField
from django.utils import timezone
from tinymce.models import HTMLField

# Create your models here.
class Portafolio(models.Model):
    '''Aqui se almacena información de mi portafolio'''
    imagen = ResizedImageField(force_format="WEBP", quality=100, upload_to='images_portafolio/', null=True, blank=True, verbose_name="Imágen")
    texto_largo = models.TextField(max_length=2000, null=False, verbose_name="Texto Largo")

    class Meta:
        verbose_name = "Portafolio"
        verbose_name_plural = "Portafolio"

    def __str__(self) -> str:
        return "Acerca De"
    
class Habilidades(models.Model):  
    descHabilidad = models.CharField(max_length=100, null=False, verbose_name="Habilidad")

    class Meta:
        verbose_name = "Habilidad"
        verbose_name_plural = "Habilidades"

    def __str__(self) -> str:
        return self.descHabilidad
    
class Certificaciones(models.Model):
    imagen = ResizedImageField(force_format="WEBP", quality=100, upload_to='images_portafolio/', null=True, blank=True, verbose_name="Imágen")
    titulo = models.CharField(max_length=50, null=False, verbose_name="Título") 
    descripcion = models.CharField(max_length=230, null=False, verbose_name="Descripción")
    enlace = models.URLField(max_length=255, null=False, verbose_name="Enlace")

    class Meta:
        verbose_name = "Certificaciones"
        verbose_name_plural = "Certificaciones"

    def __str__(self) -> str:
        return self.titulo
    
class Proyectos(models.Model):
    titulo = models.CharField(max_length=50, null=True, verbose_name="Título") 
    descripcion = models.CharField(max_length=230, null=True, verbose_name="Descripción")
    imagen = ResizedImageField(force_format="WEBP", quality=100, upload_to='images_portafolio/', null=True, blank=True, verbose_name="Imágen") 
    texto_enlace = models.CharField(max_length=50, null=True, verbose_name="Texto del Enlace")
    enlace = models.URLField(max_length=255, null=True, verbose_name="Enlace")
    alt_imagen = models.CharField(max_length=50, null=True, verbose_name="Alt Imagen")

    class Meta:
        verbose_name = "Proyecto"
        verbose_name_plural = "Proyectos"

    def __str__(self) -> str:
        return self.titulo
    

class FormularioContacto(models.Model):
    nombre = models.CharField(max_length=40, verbose_name="Nombre de la Persona", blank=False, null=False)
    correo = models.CharField(max_length=40, verbose_name="Correo de la Persona", blank=False, null=False)
    mensaje = models.CharField(max_length=4000, verbose_name="Mensaje de la Persona", blank=False, null=False)
    fecha = models.DateTimeField(auto_now_add=True, verbose_name="Enviado el",)
    es_spam = models.BooleanField(verbose_name="Spam", default=False, blank=True)
    terminos = models.BooleanField(verbose_name="Terminos", default=False)


    class Meta:
        db_table = 'formulariocontacto'
        verbose_name = "Formulario de Contacto"
        verbose_name_plural = "Formulario de Contactos"

    def __str__(self) -> str:
        return self.nombre + " " +self.correo
    
class IdentificadorEmail(models.Model):
    identificador = models.CharField(max_length=40, verbose_name="Identificador", blank=False, null=False)
    estado = models.BooleanField(verbose_name="Estado", default=False)

    class Meta:
        db_table = 'IdentificadoresEmails'
        verbose_name = "Identificador de Email"
        verbose_name_plural = "Identificador de Emails"

    def __str__(self) -> str:
        return self.identificador
    
class Emails(models.Model):
    email_address = models.CharField(max_length=60, verbose_name="Dirección de correo", unique=True)
    subscribe_to_newsletter = models.BooleanField(default=False, verbose_name="Suscribirse al boletín")

    class Meta:
        verbose_name = "Email"
        verbose_name_plural = "Emails"


class EmailsEnviados(models.Model):
    _from = models.CharField(max_length=60, verbose_name="De", blank=False, null=False)
    _to = models.CharField(max_length=100, verbose_name="A", blank=False, null=False)
    _subject = models.CharField(max_length=100, verbose_name="Asunto", blank=False, null=False)
    _body = models.CharField(max_length=4000, verbose_name="Cuerpo", blank=False, null=False)
    _datetime = models.DateField(auto_now_add=True, verbose_name="Enviado el")

    class Meta:
        db_table = 'EmailsEnviados'
        verbose_name = "Correos Enviados"
        verbose_name_plural = "Correos Enviados"

    def __str__(self) -> str:
        return self._from + " A " + self._to