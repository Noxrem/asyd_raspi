FROM alpine

# Install the gcc compiler with the musl-dev library
RUN apk update && apk add gcc musl-dev
WORKDIR /myapp
COPY hello-world.c /myapp

# Build the hello-world program dynamically
RUN gcc -o hello-world hello-world.c

# Run the program
CMD ["/myapp/hello-world"]
