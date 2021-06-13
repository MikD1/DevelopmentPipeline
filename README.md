# Development Pipeline

### Repository description

- DemoApp: Simple demo application with tests
- .github/workflows: Continuous Integration workflow
- terraform: Cloud infrastructure description

### Pipeline description

1. Create feature branch
2. PR to master
3. Code review
4. Approve
5. Build (auto)
6. Run tests (auto)
7. Push image to container registry (auto)
8. Update version in infrastructure description (auto|manually)

### How to run pipeline

1. Create Yandex Cloud account: https://console.cloud.yandex.ru/

2. Create Service account: https://cloud.yandex.ru/docs/iam/concepts/users/service-accounts
    - Roles: container-registry.images.pusher, container-registry.images.puller

2. Install Yandex Cloud CLI: https://cloud.yandex.ru/docs/cli/operations/install-cli
```
yc init
yc container registry configure-docker
yc container registry create --name demo-app-registry
yc iam key create --service-account-name <service-account> -o key.json
```

4. Install Terraform: https://learn.hashicorp.com/tutorials/terraform/install-cli
```
terraform init
terraform apply -var yc_folder=<folder> -var yc_token=<oauth_token>
```