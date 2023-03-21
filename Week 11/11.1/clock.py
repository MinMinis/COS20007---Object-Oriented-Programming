class Clock:
    def __init__(clock):
        clock._hour = Counter("Hours")
        clock._minute = Counter("Minutes")
        clock._second = Counter("Seconds")

    def tick(clock):
        if clock._second.ticks < 59:
            clock._second.increment()
        else:
            clock._second.reset()
            if clock._minute.ticks < 59:
                clock._minute.increment()
            else:
                clock._minute.reset()
                if clock._hour.ticks < 23:
                    clock._hour.increment()
                else:
                    clock._hour.reset()

    def read_time(clock):
        return f"{clock._hour.count}:{clock._minute.count}:{clock._second.count}"

    def reset(clock):
        clock._second.reset()
        clock._minute.reset()
        clock._hour.reset()


class Counter:
    def __init__(clock, name):
        clock._name = name
        clock._count = 0

    def increment(clock):
        clock._count += 1

    def reset(clock):
        clock._count = 0

    @property
    def ticks(clock):
        return clock._count

    @property
    def count(clock):
        return clock._count

    @property
    def name(clock):
        return clock._name
def main():
    print("24h - Clock:")
    time = Clock()
    for i in range(24 * 60 * 60 - 1):
        time.tick()
    print(time.read_time())
main()
