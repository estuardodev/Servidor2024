from django.db import models
from django_resized import ResizedImageField
from tinymce.models import HTMLField

# Create your models here.
class InformacionJano(models.Model):
    icono = ResizedImageField(verbose_name="Portada (512x512)", force_format="WEBP", quality=100, upload_to='imagenes_jano/')
    portada = ResizedImageField(verbose_name="Portada (1920x828)", force_format="WEBP", quality=100, upload_to='imagenes_jano/',null=True)
    frase = models.CharField(verbose_name="Frase", max_length=150, blank=True)
    texto = HTMLField(verbose_name="Contenido", null=True, blank=True, max_length=5000)
    imagen = ResizedImageField(force_format="WEBP", quality=100, upload_to='imagenes_jano/')
    ultima_actualizacion = models.DateTimeField(verbose_name="Última actualización", auto_now=True)
    estado = models.BooleanField(verbose_name="Estado", default=False)
    
    class Meta:
        db_table = "InformacionJano"
        verbose_name = "Contenido de Jano Abonce"
        verbose_name_plural = "Contenido de Jano Abonce"  
    
    def __str__(self) -> str:
        return "Información: " + str(self.id)
    
class RedesSocialesJano(models.Model):
    nombre_red_social = models.CharField(verbose_name="Nombre de la Red Social", max_length=50, blank=True, null=True)
    enlace_red_social = models.CharField(verbose_name="Enlace de la Red Social", max_length=75, null=False, blank=False)
    imagen_fondo_red_social = ResizedImageField(verbose_name="Imágen de fondo", force_format="WEBP", quality=100, upload_to='imagenes_jano/', null=False)
    icono_red_social = ResizedImageField(verbose_name="Icono de la red social (NO SVG)", force_format="WEBP", quality=100, upload_to='imagenes_jano/', null=False)
    estado = models.BooleanField(verbose_name="Estado", default=False)
    
    class Meta:
        db_table = "RedesSocialesJano"
        verbose_name = "Redes Sociales de Jano Abonce"
        verbose_name_plural = "Redes Sociales de Jano Abonce"  
    
    def __str__(self) -> str:
        return str(self.nombre_red_social)
