resource "yandex_vpc_network" "demo_app_network" {
  name = "demo-app-network"
}

resource "yandex_vpc_subnet" "demo_app_subnet_a" {
  name           = "demo-app-subnet-a"
  v4_cidr_blocks = ["10.2.0.0/16"]
  zone           = "ru-central1-a"
  network_id     = yandex_vpc_network.demo_app_network.id
}

resource "yandex_vpc_subnet" "demo_app_subnet_b" {
  name           = "demo-app-subnet-b"
  v4_cidr_blocks = ["10.3.0.0/16"]
  zone           = "ru-central1-b"
  network_id     = yandex_vpc_network.demo_app_network.id
}
