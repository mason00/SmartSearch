import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SearchHubServiceService {

  constructor() {
    const connection = new HubConnectionBuilder()
    .withUrl(`${environment.smartSearchUrl}/searchhub`)
    // .withUrl('https://smartsearchlinux.azurewebsites.net/searchhub')
    .configureLogging(LogLevel.Information)
    .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");

            await connection.invoke("SendMessage", 'test', 'hello');
        } catch (err) {
            console.log(err);
        }
    };

    connection.on('ReceiveMessage', function (name, message) {
      console.log('ReceiveMessage', name, message);
    });

    // Start the connection.
    start();
  }
}
