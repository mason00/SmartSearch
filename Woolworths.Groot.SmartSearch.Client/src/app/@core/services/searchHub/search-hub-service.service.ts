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

            connection.stream('FullTextSearchChannel')
              .subscribe({
                  next: (item) => {
                    console.log('FullTextSearchChannel', item);
                  },
                  complete: () => {
                    console.log('FullTextSearchChannel complete');
                  },
                  error: (err) => {
                    console.log('FullTextSearchChannel error', err);
                  },
            });
        } catch (err) {
            console.log(err);
            setInterval(start, 10000);
        }
    };

    connection.on('ReceiveMessage', function (name, message) {
      console.log('ReceiveMessage', name, message);
    });

    connection.on('OnFullTextSearch', function (term) {
      console.log('OnFullTextSearch', term);
    });

    // Start the connection.
    start();
  }
}
