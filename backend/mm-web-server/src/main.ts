import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);

  const routePrefix = 'mm-webserver';
  const port = process.env.PORT || 8080;
  await app
    .listen(port)
    .then(() =>
      console.log(`Application listening on: ${port}/${routePrefix}/api`),
    );
}
bootstrap();
