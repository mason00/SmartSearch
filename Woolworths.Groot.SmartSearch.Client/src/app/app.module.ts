import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { reducer } from '@core/store/link-click.reducer';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { WebShellModule } from '@shell/web-shell.module';
import { CoreModule } from './@core/core.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule,
    CoreModule,
    WebShellModule,
    BrowserAnimationsModule,
    NgbModule,
    StoreModule.forRoot({linkClickInfo: reducer}),
    StoreDevtoolsModule.instrument({
      maxAge: 50,
    }),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
