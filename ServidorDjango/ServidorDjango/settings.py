import os
import environ
from pathlib import Path

# Build paths inside the project like this: BASE_DIR / 'subdir'.
BASE_DIR = Path(__file__).resolve().parent.parent

# Ruta compartida
SHARE_DIR = os.path.dirname(BASE_DIR)

env = environ.Env(
    # set casting, default value
    DEBUG=(bool, False)
)

# Ruta del archivo que contiene las variables de entorno
environ.Env.read_env(os.path.join(BASE_DIR, '.env'))

# SECURITY WARNING: keep the secret key used in production secret!
SECRET_KEY = env('SECRET_KEY')

# SECURITY WARNING: don't run with debug turned on in production!
DEBUG = env('DEBUG')

ALLOWED_HOSTS = env.list('ALLOWED_HOSTS') # Dominios permitidos para el proyecto

CSRF_TRUSTED_ORIGINS = env.list('TRUSTED_ORIGINS') # Dominios permitidos para el administrador

# Seguridad del sitio

CSRF_COOKIE_SECURE =  env.bool('CSRF_COOKIE_SECURE') # Configuración para garantizar cookies CSRF seguras
SESSION_COOKIE_SECURE =  env.bool('SESSION_COOKIE_SECURE') # Configuración para garantizar cookies de sesión seguras
SECURE_SSL_REDIRECT =  env.bool('SECURE_SSL_REDIRECT') # Configuración para redirigir automáticamente todas las conexiones HTTP a HTTPS
SECURE_HSTS_SECONDS =  env.int('SECURE_HSTS_SECONDS') # Configuración para habilitar HTTP Strict Transport Security (HSTS)
SECURE_HSTS_INCLUDE_SUBDOMAINS =  env.bool('SECURE_HSTS_INCLUDE_SUBDOMAINS') # Configuración para indicar que todos los subdominios deben ser servidos exclusivamente a través de SSL
SECURE_HSTS_PRELOAD =  env.bool('SECURE_HSTS_PRELOAD') # Configuración para permitir la inclusión en la lista de precarga del navegador
SILENCED_SYSTEM_CHECKS =  env.list('SILENCED_SYSTEM_CHECKS') # Advertencias silenciadas con motivos y soluciones coherentes


# Application definition

INSTALLED_APPS = [
    'django.contrib.admin',
    'django.contrib.auth',
    'django.contrib.contenttypes',
    'django.contrib.sessions',
    'django.contrib.messages',
    'django.contrib.staticfiles',

    'Portafolio.apps.PortafolioConfig',
    'Blog.apps.BlogConfig',
    'JanoAbonce.apps.JanoabonceConfig',
    'Legal.apps.LegalConfig',

    'django_hosts',
    'tinymce',
]

MIDDLEWARE = [
    # Django hosts
    'django_hosts.middleware.HostsRequestMiddleware',

    'django.middleware.security.SecurityMiddleware',
    'django.contrib.sessions.middleware.SessionMiddleware',
    'django.middleware.common.CommonMiddleware',
    'django.middleware.csrf.CsrfViewMiddleware',
    'django.contrib.auth.middleware.AuthenticationMiddleware',
    'django.contrib.messages.middleware.MessageMiddleware',
    'django.middleware.clickjacking.XFrameOptionsMiddleware',

    # Django hosts
    'django_hosts.middleware.HostsResponseMiddleware',
]

ROOT_URLCONF = 'ServidorDjango.urls'

# Django hosts
ROOT_HOSTCONF = 'ServidorDjango.hosts'
DEFAULT_HOST = 'www'

TEMPLATES = [
    {
        'BACKEND': 'django.template.backends.django.DjangoTemplates',
        'DIRS': [],
        'APP_DIRS': True,
        'OPTIONS': {
            'context_processors': [
                'django.template.context_processors.debug',
                'django.template.context_processors.request',
                'django.contrib.auth.context_processors.auth',
                'django.contrib.messages.context_processors.messages',
            ],
        },
    },
]

WSGI_APPLICATION = 'ServidorDjango.wsgi.application'


# Database
# https://docs.djangoproject.com/en/4.2/ref/settings/#databases

DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.postgresql_psycopg2',
        'NAME':  env('NAME_DB'),
        'USER':  env('USER_DB'),
        'PASSWORD':  env('PASS_DB'),
        'HOST':  env('HOST_DB'),
        'PORT':     env('PORT_DB'),
    }
}

# Resend
# https://resend.com/docs/introduction

EMAIL_BACKEND =  env('EMAIL_BACKEND_SC')
RESEND_SMTP_PORT =  env('RESEND_SMTP_PORT_SC')
RESEND_SMTP_USERNAME =  env('RESEND_SMTP_USERNAME_SC')
RESEND_SMTP_HOST =  env('RESEND_SMTP_HOST_SC')
RESEND_API_KEY =  env('RESEND_API_KEY_SC')


# Password validation
# https://docs.djangoproject.com/en/4.2/ref/settings/#auth-password-validators

AUTH_PASSWORD_VALIDATORS = [
    {
        'NAME': 'django.contrib.auth.password_validation.UserAttributeSimilarityValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.MinimumLengthValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.CommonPasswordValidator',
    },
    {
        'NAME': 'django.contrib.auth.password_validation.NumericPasswordValidator',
    },
]


# Internationalization
# https://docs.djangoproject.com/en/4.2/topics/i18n/

LANGUAGE_CODE = 'es-us'

TIME_ZONE = 'America/Guatemala'

USE_I18N = True

USE_TZ = True


# Static files (CSS, JavaScript, Images)
# https://docs.djangoproject.com/en/4.2/howto/static-files/

STATIC_URL = 'static/'
STATIC_ROOT = os.path.join(BASE_DIR, 'static/')


# Media files (Images, Videos, Audios)
if DEBUG:
    MEDIA_ROOT = os.path.join(SHARE_DIR, 'ServidorASP', 'wwwroot', 'media')
    MEDIA_URL = '/media/'
else:
    MEDIA_ROOT = os.path.join(SHARE_DIR, 'ServidorASP','bin', 'Release', 'net8.0', 'publish', 'wwwroot', 'media')
    MEDIA_URL = '/media/'


# Default primary key field type
# https://docs.djangoproject.com/en/4.2/ref/settings/#default-auto-field

DEFAULT_AUTO_FIELD = 'django.db.models.BigAutoField'
