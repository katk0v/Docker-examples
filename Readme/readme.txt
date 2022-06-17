Собрать образ для Python приложения:
docker build -t web-hello .

Запустить контейнер (автоудаление после остановки контейнера):
docker run --rm --name web -p 8080:8080 web-hello

В консоли будет написано что-то типа:

 * Serving Flask app "app" (lazy loading)
 * Environment: production
   WARNING: This is a development server. Do not use it in a production deployment.
   Use a production WSGI server instead.
 * Debug mode: on
 * Running on all addresses.
   WARNING: This is a development server. Do not use it in a production deployment.
 * Running on http://172.17.0.2:8080/ (Press CTRL+C to quit)
 * Restarting with stat
 * Debugger is active!
 * Debugger PIN: 256-742-296

 http://172.17.0.2:8080/ -- этот адрес нужно будет прописать потом в .NET приложении, его докер присваивает контейнеру (там прост захардкодить, тестовый проектик же)



 Запросы (результаты есть на скринах):
 http://localhost:80/api/post (post)
http://localhost:80/api/get (get)