FROM alpine as builder

RUN apk update && apk add gcc musl-dev

WORKDIR /app
COPY hello-world.c /app

# compile and link dynamically
RUN gcc -o hello-world hello-world.c

FROM alpine

WORKDIR /app
COPY --from=builder /app/hello-world /app
CMD ["/app/hello-world"]
