Собрать образ:
docker build -t web-hello .

Запустить контейнер (автоудаление после остановки):
docker run --rm --name web -p 8080:8080 web-hello

