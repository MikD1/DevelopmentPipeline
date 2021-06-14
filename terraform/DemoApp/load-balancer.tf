resource "yandex_lb_network_load_balancer" "demo_app_lb" {
  name = "demo-app-lb"

  listener {
    name = "demo-app-listener"
    port = 80
    external_address_spec {
      ip_version = "ipv4"
    }
  }

  attached_target_group {
    target_group_id = yandex_compute_instance_group.demo_app_instances.load_balancer.0.target_group_id

    healthcheck {
      name = "demo-app-http-hc"
      http_options {
        port = 80
        path = "/api/healthy"
      }
    }
  }
}
