package ru.geekbrains;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.StandardCharsets;

public class WebServer {

    public static void main(String[] args) {

        try (ServerSocket serverSocket = new ServerSocket(8088)){

            while (true) {
                Socket socket = serverSocket.accept(); // позволяет подключаться клиентам
                System.out.println("New client connected");

                BufferedReader input = new BufferedReader(                        // 3. класс, который накапливает символы и выдает построчно
                        new InputStreamReader(                                    // 2. читать байты неудобно, InputStreamReader переводит байты в символы, но по одному
                                socket.getInputStream(), StandardCharsets.UTF_8));// 1. с помощью InputStream мы считываем байты, приходящие от подключившегося клиента через serverSocket.accept() 15 строчка

                PrintWriter output = new PrintWriter(socket.getOutputStream());   // создаем класс, который считывает байты и переводит в символы, выводим в окне браузера


                while (!input.ready()) ; // ждем, пока что-то появится, когда вернет true - выходим, пока false - висим

                while (input.ready()) {  // дождались когда true - считываем
                    System.out.println(input.readLine());
                }

                output.println("HTTP/1.1 200 OK");                        // 200 - код, подключение совершено
                output.println("Content-Type: text/html; charset=utf-8"); // добавляем кодировку текста, который мы собираемся отправлять в качестве ответа на запрос
                output.println();                                         // чтобы указать, что все заголовки закончились нужно вставить пустую строку, далее начинается содержимое файла

                output.println("<h1>Привет от сервера</h1>");             // пишем что-то на странице
                output.flush();                                           // указываем, что нужно отправить СЕЙЧАС, пропихивает отправку информации


                input.close();
                output.close();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }


    }
}

