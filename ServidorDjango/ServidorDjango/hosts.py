from django.conf import settings
from django_hosts import patterns, host
import os
import environ

BASE_DIR = settings.BASE_DIR

env = environ.Env(
    # set casting, default value
    DEBUG=(bool, False)
)

# Ruta del archivo que contiene las variables de entorno
environ.Env.read_env(os.path.join(BASE_DIR, '.env'))


host_patterns = patterns(
    '',
    host(r'www', settings.ROOT_URLCONF, name="www"),
    host(fr'{env.str("SUB_DOMAIN_ONE")}', 'Portafolio.urls', name="admin"),
    host(fr'{env.str("SUB_DOMAIN_TWO")}', 'JanoAbonce.urls', name="janoabonceAdmin"),
    host(fr'{env.str("SUB_DOMAIN_THREE")}', 'Blog.urls', name="apiBlog"),
)
