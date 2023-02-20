import redis
import random

redis_server = redis.Redis()# чтобы создать соединение, присваиваем его переменной 
redis_server.close()        # но ВСЕГДА необходимо указывать, когда нужно закрыть подключение
                            # поэтому существует очень удобная конструкция with, когда отступы заканчиваются, подключение автоматически прерывается
with redis.Redis() as redis_server: # redis.Redis() - соединение, redis_server - переменная
    redis_server.lpush("queue", random.randint(0, 10))

