# MusicService.Api

Сервис для домашнего прослушивания музыки.

## Стек технологий

* .NET 10 / ASP.NET Core (Minimal API)
* Встроенный DI-контейнер
* Serilog (Console + File, rolling по дням)
* Фоновые задачи (BackgroundService)

## Как запустить

1. Установите .NET 10 SDK.
2. Клонируйте репозиторий.
3. В корневой папке выполните:
   ```bash
   dotnet run
   ```
   
## API Endpoints

| Метод | Путь | Описание | Тело запроса | Ответы |
| :--- | :--- | :--- | :--- | :--- |
| `GET` | `/songs` | Получить список всех песен | Нет | `200 OK` |
| `GET` | `/songs/{id}` | Получить песню по ID | Нет | `200 OK`, `404 Not Found` |
| `POST` | `/songs` | Добавить новую песню | JSON (SongCreateDto) | `201 Created`, `400 Bad Request` |
| `DELETE` | `/songs/{id}` | Удалить песню по ID | Нет | `204 No Content`, `404 Not Found` |

### Особенности валидации (POST /songs)

Поле title обязательно для заполнения. Если оно пустое или состоит из пробелов, вернется 400 Bad Request.

Пример тела запроса:
```http
POST http://localhost:5095/songs
Content-Type: application/json

{
  "title": "Bohemian Rhapsody",
  "album": "My Album",
  "mainArtists": ["Queen"],
  "featuringArtists": [],
  "genres": ["Rock"],
  "releaseDate": "1988-02-12",
  "trackNumber": 1,
  "audioStreamUrl": "https://example.com/audio.mp3",
  "coverUrl": "https://example.com/logo.jpg",
  "videoUrl": "https://example.com/vidro.mp4",
  "lyrics": "Song text"
}
```

## Changelog

### 0.0.0

Реализованы:
* `GET /songs/`
* `GET /songs/{id}`
* `POST /songs`
* `DELETE /songs/{id}`

Добавлено логирование запросов.

Добавлен Middleware.

Добавлена фоновая задача, имитирующая периодическое сканирование системы.

### 1.0.0

`POST /songs` принимает `SongCreateDto` вместо `Song`.
`POST /songs` больше не возвращает `409 Conflict`

### 1.0.1

Добавлен `Serilog`.
Логирование ведётся в `logs/MusicService.Api/`
