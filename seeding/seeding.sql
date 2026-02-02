INSERT INTO MovieTheater (MovieTheaterId, Name, Status) VALUES 
('MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5C', 'Sala IMAX - Grand Central', 'Available'),
('MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5D', 'Sala 3D - Norte', 'Available'),
('MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5E', 'Cine Premium - VIP', 'Available');

INSERT INTO Movie (MovieId, Name, Duration, Status, Slug, Description) VALUES 
('MV_01H1KRYN5B7W1P8X9Y2Z3A4001', 'Spiderman no way home', 148, 'NowPlaying', 'spiderman-no-way-home', 'Peter Parker busca la ayuda del Doctor Strange para que el mundo olvide su identidad, desencadenando el caos multiversal.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4002', 'Superman legacy', 155, 'NowPlaying', 'superman-legacy', 'La historia de los viajes de Superman para reconciliar su herencia kryptoniana con su educación humana.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4003', 'Green lantern', 114, 'NowPlaying', 'green-lantern', 'Un piloto de pruebas recibe un anillo místico que le otorga poderes intergalácticos como parte de una fuerza policial espacial.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4004', 'Supergirl: Woman of tomorow', 130, 'NowPlaying', 'supergirl-woman-of-tomorow', 'Kara Zor-El viaja a través de las estrellas en una aventura épica que la define más allá de la sombra de su primo.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4005', 'Shazam', 132, 'NowPlaying', 'shazam', 'Un adolescente puede transformarse en un superhéroe adulto con solo pronunciar una palabra mágica.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4006', 'KarateKid', 126, 'NowPlaying', 'karate-kid', 'Un joven aprende artes marciales para defenderse y descubre que el karate es mucho más que pelear.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4007', 'DragonBallZ', 95, 'NowPlaying', 'dragon-ball-z', 'Goku y los Guerreros Z defienden la Tierra de amenazas alienígenas en batallas de proporciones cósmicas.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4008', 'Los increibles', 115, 'NowPlaying', 'los-increibles', 'Una familia de superhéroes encubiertos intenta vivir una vida suburbana normal hasta que son llamados a la acción.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4009', 'Megamente', 95, 'NowPlaying', 'megamente', 'Un supervillano brillante pero fracasado finalmente derrota a su némesis, solo para descubrir que la vida no tiene sentido sin un héroe.'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4010', 'Kunfupanda', 92, 'NowPlaying', 'kunfupanda', 'Po, un panda torpe, es elegido inesperadamente como el Guerrero Dragón para salvar el Valle de la Paz.');

INSERT INTO MovieImage (MovieImageId, Url, MovieId) VALUES 
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I01', 'https://cdn.mos.cms.futurecdn.net/ZykbqpVRia9y9Yg3RA7MgD.jpg', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4001'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I02', 'https://images-na.ssl-images-amazon.com/images/I/81T0GmGsrZL.jpg', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4001'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I03', 'https://i.redd.it/5235fsp42xza1.jpg', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4002'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I04', 'https://i.pinimg.com/originals/e3/32/54/e332543a4851c75ac7a91b35d75d4133.jpg', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4002'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I05', 'https://i.pinimg.com/originals/2f/ef/86/2fef86a779189a6f1780ff4968c11ef1.jpg', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4003'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I07', 'https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1706895752-815RzbuvdqL.jpg?crop=1xw:1xh;center,top&resize=980:*', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4004'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I09', 'https://preview.redd.it/the-supergirl-woman-of-tomorrow-2026-poster-continues-a-v0-l20onehia3ef1.jpeg?width=539&auto=webp&s=5667a62ec99be7754388b8fb06cc3c5184d30a2f', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4005'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I11', 'https://i5.walmartimages.com/seo/Pop-Culture-Graphics-The-Karate-Kid-Movie-Poster-Print-27-x-40_2cf9b47f-648e-47f0-88b6-8399145e4693.42df0064f021dee6a01a6a37ff2dd18a.jpeg?odnHeight=580&odnWidth=580&odnBg=FFFFFF', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4006'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I13', 'https://i5.walmartimages.com/seo/Dragonball-Super-Anime-Manga-TV-Show-Poster-Goku-Son-Goku-Panels_06ddef42-df8a-42cc-bfb7-f3d37beaa6f1.b55152e632caeb750914b6ef10742d8d.jpeg?odnHeight=580&odnWidth=580&odnBg=FFFFFF', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4007'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I15', 'https://i.pinimg.com/originals/d1/33/40/d13340978ff4d34c5b850dbcd4db5a6e.jpg', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4008'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I17', 'https://m.media-amazon.com/images/I/51zFjYOtuJL.jpg', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4009'),
('MVI_01H1KRYN5B7W1P8X9Y2Z3A4I18', 'https://m.media-amazon.com/images/I/51C2r6vwyjL.jpg', 'MV_01H1KRYN5B7W1P8X9Y2Z3A4010');

INSERT INTO MovieMovieTheater (MovieId, MovieTheaterId, PublicationDate, EndDate) VALUES 
('MV_01H1KRYN5B7W1P8X9Y2Z3A4001', 'MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5C', '2025-01-01', '2025-12-31'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4002', 'MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5C', '2025-01-01', '2025-12-31'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4003', 'MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5D', '2025-01-01', '2025-12-31'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4004', 'MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5D', '2025-01-01', '2025-12-31'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4005', 'MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5E', '2025-01-01', '2025-12-31'),
('MV_01H1KRYN5B7W1P8X9Y2Z3A4006', 'MVTHR_01H1KRYN5B7W1P8X9Y2Z3A4B5E', '2025-01-01', '2025-12-31');