FROM node:16.14-alpine3.14

EXPOSE 4200

RUN mkdir -p /usr/app/

WORKDIR /usr/app/

COPY ./package.json .

RUN npm install -g npm@8.5.1

RUN npm install --force

COPY . .

RUN npm install -g @angular/cli

CMD ["npm", "start"]