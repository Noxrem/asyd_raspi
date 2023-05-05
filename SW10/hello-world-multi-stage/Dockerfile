# file Dockerfile(multi-stage)
FROM gcc as builder

WORKDIR /myapp
COPY hello-world.c /myapp
RUN gcc -o hello-world hello-world.c

FROM debian

WORKDIR /myapp
COPY --from=builder /myapp/hello-world /myapp
CMD ["/myapp/hello-world"]
