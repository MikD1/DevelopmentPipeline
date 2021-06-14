resource "yandex_iam_service_account" "demo_app_ig_sa" {
  name        = "${var.user}-demo-app-ig-sa"
  description = "Service account to manage IG"
}

resource "yandex_resourcemanager_folder_iam_binding" "folder_editor" {
  folder_id = var.yc_folder
  role      = "editor"
  members = [
    "serviceAccount:${yandex_iam_service_account.demo_app_ig_sa.id}",
  ]
  sleep_after = 30
}

resource "yandex_iam_service_account" "demo_app_node_sa" {
  name        = "${var.user}-demo-app-node-sa"
  description = "Service account to manage docker images on nodes"
}

resource "yandex_resourcemanager_folder_iam_binding" "folder_puller" {
  folder_id = var.yc_folder
  role      = "container-registry.images.puller"
  members = [
    "serviceAccount:${yandex_iam_service_account.demo_app_node_sa.id}",
  ]
}
