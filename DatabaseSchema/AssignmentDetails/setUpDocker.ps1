## Run this script only once to setup docker image.

docker pull postgres
if (-not $?) { exit 1 }
docker run --name employee-database-container -p "7777:5432" -e POSTGRES_PASSWORD=guest -d postgres

