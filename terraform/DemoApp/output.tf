locals {
  lbaddress = tolist(tolist(yandex_lb_network_load_balancer.demo_app_lb.listener).0.external_address_spec).0.address
  lbport    = tolist(yandex_lb_network_load_balancer.demo_app_lb.listener).0.port
}

output "instance_group_id" {
  value = yandex_compute_instance_group.demo_app_instances.id
}

output "lb_address" {
  value = "${local.lbaddress}:${local.lbport}"
}
