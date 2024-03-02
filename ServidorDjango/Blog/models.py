from django.db import models
from django_resized import ResizedImageField
from tinymce.models import HTMLField

# Create your models here.
class EstadoArticulos(models.Model):
    estado = models.BooleanField(default=True, verbose_name="Estado")  

    class Meta:
        db_table = 'EstadoArticulos'
        verbose_name = "Estados de Articulos"
        verbose_name_plural = "Estados de Articulos"

    def __str__(self) -> str:
        if self.estado == True:
            return "Activo"
        else:
            return "Desactivado"
        
class Autores(models.Model):
    nombre_autor = models.CharField(verbose_name="Autor",max_length=50)

    class Meta:
        db_table = "Autores"
        verbose_name = "Autores"
        verbose_name_plural = "Autores"

    def __str__(self):
        return self.nombre_autor

class Categoria(models.Model):
    nombre = models.CharField(max_length=100, verbose_name="Nombre de la Categoría")

    class Meta:
        db_table = "Categoria"
        verbose_name = "Categoría"
        verbose_name_plural = "Categorías"

    def __str__(self):
        return self.nombre

class Articulo(models.Model):
    titulo = models.CharField(verbose_name="Título",max_length=150)
    descripcion = models.CharField(verbose_name="Descripcion SEO",max_length=360, null=True)
    tags = models.CharField(verbose_name="TAGS",max_length=400, null=True)
    url = models.CharField(verbose_name="URL",max_length=500)
    contenido = HTMLField(verbose_name="Contenido",max_length=30000)
    fecha_hora_creacion = models.DateTimeField(verbose_name="Fecha y Hora de Creación",auto_now_add=True, null=True)
    visitas = models.IntegerField(default=0, verbose_name="Total Visitas", null=True) 
    likes = models.IntegerField(default=0, verbose_name="Likes", null=True)
    compartidos = models.IntegerField(default=0, verbose_name="Veces Compartidas", null=True)
    prioridad = models.FloatField(verbose_name="Prioridad del sitio", default=0.9)
    image = ResizedImageField(verbose_name="Imágen del artículo",force_format="WEBP", quality=100, upload_to='images/', null=True, blank=True)
    descripcion_imagen = models.CharField(verbose_name="Informacion de la imágen",max_length=150, null=True, blank=True)

    categorias = models.ManyToManyField(Categoria, verbose_name="Categorías")
    estado = models.ForeignKey(EstadoArticulos, on_delete=models.SET_NULL, null=True, verbose_name="Estado")
    autor = models.ManyToManyField(Autores, verbose_name="Autor")
    
    class Meta:
        db_table = "Articulo"
        verbose_name = "Articulo"
        verbose_name_plural = "Articulos"

    def __str__(self) -> str:
        return self.titulo + " ID: " + str(self.id)
