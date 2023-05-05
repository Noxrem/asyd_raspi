# file Dockerfile (single-state)
FROM gcc
WORKDIR /myapp
COPY hello-world.c /myapp
RUN gcc -o hello-world hello-world.c
CMD ["/myapp/hello-world"]
