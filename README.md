# Secure Messaging Service - RSA Encryption

This repository contains a **secure messaging service** that uses **RSA Encryption** to encrypt and decrypt messages between a **Client** and a **Server**. The service includes a Web API on the server side to handle encryption/decryption requests, and a client that interacts with the API for secure communication.

## Overview

- **RSA Encryption**: Uses a 2048-bit RSA key to encrypt and decrypt messages.
- **Server**: A Web API project that exposes endpoints for encryption and decryption.
- **Client**: A simple client-side application to interact with the server for encryption and decryption operations.
- **Unit Tests**: Unit tests for both service and controller to ensure correctness.

## Project Structure

The project is divided into two main parts:

- **Server**: Implements the Web API for encryption and decryption functionality.
    - Handles encryption and decryption requests from the client.
    - Provides endpoints to retrieve public keys and send encrypted/decrypted messages.
    - Located in the `Server` directory.
  
- **Client**: A simple application to interact with the server and send messages for encryption/decryption.
    - Sends messages to the server, retrieves the public key, encrypts the message, and decrypts it using the RSA algorithm.
    - Located in the `Client` directory.

## Prerequisites

- **.NET 6.0** or higher for both Server and Client projects.
- **Visual Studio** or any .NET compatible IDE.
- **xUnit** for unit testing.
