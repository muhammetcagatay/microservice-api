
<div align="center">
  
[![Docker](https://img.shields.io/badge/Docker-available-green.svg?style=flat&logo=docker)](https://github.com/muhammetcagatay/microservice-api#electric_plug-installation)
[![GitHub](https://img.shields.io/github/license/emalderson/ThePhish)](https://github.com/emalderson/ThePhish/blob/master/LICENSE)
[![Documentation](https://img.shields.io/badge/Documentation-complete-green.svg?style=flat)](https://github.com/muhammetcagatay/microservice-api)
  
</div>


<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/muhammetcagatay/VivaceAPI">
    <img src="https://miro.medium.com/max/1024/0*FiZBsN6fu2FuH7nw.png" alt="Logo" width="200">
  </a>

  <p align="center">
    The main idea of ​​creating this project is to implement microservices architecture with  latest technology such as .Net 6, MongoDB, PostgreSQL, Docker.
    <br />

    -->
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#beginner-about-the-project">About The Project</a></li>
    <li><a href="#-features">Features</a></li>
    <li><a href="#hammer-built-with">Built With</a></li>
    <li><a href="#electric_plug-installation">Installation</a></li>
    <li>
      <a href="#wrench-devolopment">Devolopment</a>
      <ul>
        <li><a href="#file_folder-file-structure">File Structure</a></li>
        <li><a href="#nut_and_bolt-database-design">Database Design</a></li>
      </ul>
    </li>
    <li><a href="#earth_americas-endpoints">Endpoints</a></li>
    
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## :beginner: About The Project

<div align="center">

![Movie Services](assets/architecture_diagram.png)

</div>




There are many great README templates available on GitHub; however, I didn't find one that really suited my needs so I created this enhanced one. I want to create a README template so amazing that it'll be the last one you ever need -- I think this is it.

Here's why:
* Your time should be focused on creating something amazing. A project that solves a problem and helps others
* You shouldn't be doing the same tasks over and over like creating a README from scratch
* You should implement DRY principles to the rest of your life :smile:

Of course, no one template will serve all projects since your needs may be different. So I'll be adding more in the near future. You may also suggest changes by forking this repo and creating a pull request or opening an issue. Thanks to all the people have contributed to expanding this template!

Use the `BLANK_README.md` to get started.

## 🎯 Features
-   [Microservices Architecture](https://github.com/muhammetcagatay/microservice-api/tree/master/src)
-   [Rest API](https://github.com/muhammetcagatay/microservice-api/tree/master/src/Movie/Movie.API)
-   [Logging](https://github.com/muhammetcagatay/microservice-api/blob/master/src/Movie/Movie.API/Logging/CustomLoggerFactory.cs)
-   [Middlewares](https://github.com/muhammetcagatay/microservice-api/tree/master/src/Movie/Movie.API/Middlewares)
-   [Filters](https://github.com/muhammetcagatay/microservice-api/blob/master/src/Book/Book.API/Filters/NotFoundFilter.cs)
-   [API Gateway](www.empty.com)
-   [Repository Pattern](https://github.com/muhammetcagatay/microservice-api/tree/master/src/Movie/Movie.API/Data)
-   [AutoMapper](https://github.com/muhammetcagatay/microservice-api/tree/master/src/Book/Book.API/Mapper)
-   [Options Pattern](https://github.com/muhammetcagatay/microservice-api/tree/master/src/Movie/Movie.API/Models/Settings)
-   [Swagger Integration](https://github.com/muhammetcagatay/microservice-api/blob/master/src/Book/Book.API/Program.cs)
-   [UnitOfWork Pattern](https://github.com/muhammetcagatay/microservice-api/tree/master/src/Book/Book.API/Data/UnitOfWorks)

## :hammer: Built With

You can take a look at the programming languages, frameworks, databases and other tools I used while developing the project below.

* [.Net Core](https://nextjs.org/)
* [Docker](https://reactjs.org/)
* [MongoDB](https://vuejs.org/)
* [PostgreSQL](https://angular.io/)
* [Postman](https://svelte.dev/)
* [DBeaver](https://laravel.com)
* [EF Core](https://getbootstrap.com)
* [Ocelot](https://getbootstrap.com)


## :electric_plug: Installation

1. Clone the repo
   ```sh
   git clone https://github.com/muhammetcagatay/microservice-api.git
   ```
2. Go to project folder
   ```sh
   cd microservice-api
   ```
3. Docker compose
   ```sh
   docker-compose up
   ```


<!-- GETTING STARTED -->
## :wrench: Devolopment

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### :file_folder: File Structure

Add a file structure here with the basic details about files, below is an example.

```
├── src
│   ├── Movie
│   │   ├── Movie.API
│   │   └── Movie.sln
│   ├── Book
│   │   ├── Book.API
│   │   └── Book.sln
│   ├── Gateway
│   │   ├── APIGateway
│   │   └── APIGateway.sln
├── .gitattributes
├── .gitignore
├── README.md
├── docker-compose.override.yml
└── docker-compose.yml
```



### :nut_and_bolt: Database Design

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Get a free API Key at [https://example.com](https://example.com)
2. Clone the repo
   ```sh
   git clone https://github.com/your_username_/Project-Name.git
   ```
3. Install NPM packages
   ```sh
   npm install
   ```
4. Enter your API in `config.js`
   ```js
   const API_KEY = 'ENTER YOUR API';
   ```
<!-- Endpoints -->
## :earth_americas: Endpoints
Now that we’ve learned about the anatomy of our endpoints and the different request methods that we should use, it’s time for some examples:

### Book Service

| Method | URL | Description |
| --- | --- | --- |
| `GET` | `api/actors` | `List of all actors` |

### Movie Service

| Method | URL | Description |
| --- | --- | --- |
| `GET` | `api/actors` | `List of all actors` |

<!-- USAGE EXAMPLES -->
## :zap: Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_




<!-- ROADMAP -->
## :rocket: Roadmap

- [x] Develop Book service
- [x] Develop Movie service
- [x] Develop API Gateway
- [x] Dockerize the project
- [ ] documentation


See the [open issues](https://github.com/othneildrew/Best-README-Template/issues) for a full list of proposed features (and known issues).


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/othneildrew/Best-README-Template/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/othneildrew/Best-README-Template/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/othneildrew/Best-README-Template/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/othneildrew/Best-README-Template/issues
[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/othneildrew/Best-README-Template/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/othneildrew
[product-screenshot]: images/screenshot.png

