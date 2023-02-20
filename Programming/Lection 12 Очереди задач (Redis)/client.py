import redis

with redis.Redis() as redis_client:
    value = redis_client.rpop("queue")

print(int(value)) # строки хранятся в байтах