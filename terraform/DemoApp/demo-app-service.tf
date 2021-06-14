data "yandex_compute_image" "coi" {
  family = "container-optimized-image"
}

data "yandex_container_registry" "demo_app_registry" {
  name      = local.registry_name
  folder_id = var.yc_folder
}

data "template_file" "docker_spec" {
  template = file("${path.module}/files/spec.yaml")
  vars = {
    docker_image = "cr.yandex/${data.yandex_container_registry.demo_app_registry.id}/demo-app:latest"
  }
}

resource "yandex_compute_instance_group" "demo_app_instances" {
  name               = "demo-app-ig-2"
  folder_id          = var.yc_folder
  service_account_id = yandex_iam_service_account.demo_app_ig_sa.id
  instance_template {
    platform_id = "standard-v2"
    resources {
      memory = 2
      cores  = 2
    }
    boot_disk {
      mode = "READ_WRITE"
      initialize_params {
        image_id = data.yandex_compute_image.coi.id
        size     = 10
      }
    }
    network_interface {
      network_id = yandex_vpc_network.demo_app_network.id
      nat        = "true"
    }
    service_account_id = yandex_iam_service_account.demo_app_node_sa.id
    metadata = {
      ssh-keys                     = "${var.user}:${file("~/.ssh/yc-demo-app-ig.pub")}"
      docker-container-declaration = "${data.template_file.docker_spec.rendered}"
    }
  }

  scale_policy {
    fixed_scale {
      size = 2
    }
  }

  allocation_policy {
    zones = [
      "ru-central1-a",
      "ru-central1-b"
    ]
  }

  deploy_policy {
    max_unavailable = 1
    max_expansion   = 1
  }

  load_balancer {
    target_group_name = "tg-ig"
  }

  depends_on = [
    yandex_resourcemanager_folder_iam_binding.folder_editor
  ]
}
