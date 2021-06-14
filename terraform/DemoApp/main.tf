terraform {
  required_providers {
    yandex = {
      source = "yandex-cloud/yandex"
    }
  }
}

provider "yandex" {
  endpoint  = "api.cloud.yandex.net:443"
  token     = var.yc_token
  folder_id = var.yc_folder
  zone      = "ru-central1-a"
}

locals {
  registry_name = "demo-app-registry"
}
