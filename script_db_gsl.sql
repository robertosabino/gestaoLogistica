CREATE TABLE `depositos` (
  `iddeposito` varchar(36) NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `ativo` tinyint(4) DEFAULT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `imagem` varchar(255) DEFAULT NULL,
  `latitude` double DEFAULT NULL,
  `longitude` double DEFAULT NULL,
  PRIMARY KEY (`iddeposito`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `permissoes` (
  `idpermissao` varchar(36) NOT NULL,
  `modulo` varchar(100) DEFAULT NULL,
  `nome` varchar(100) DEFAULT NULL,
  `incluir` tinyint(4) DEFAULT NULL,
  `ler` tinyint(4) DEFAULT NULL,
  `editar` tinyint(4) DEFAULT NULL,
  `deletar` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`idpermissao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `perfil` (
  `idperfil` varchar(36) NOT NULL,
  `nome` varchar(150) DEFAULT NULL,
  `ativo` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`idperfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `permissoesperfil` (
  `idPerfil` varchar(36) NOT NULL,
  `idPermissao` varchar(36) NOT NULL,
  `idPermissoesPerfil` varchar(36) NOT NULL,
  PRIMARY KEY (`idPermissoesPerfil`),
  KEY `fkperfil_idx` (`idPerfil`),
  KEY `fkpermissao_idx` (`idPermissao`),
  CONSTRAINT `fkperfil` FOREIGN KEY (`idPerfil`) REFERENCES `perfil` (`idperfil`),
  CONSTRAINT `fkpermissao` FOREIGN KEY (`idPermissao`) REFERENCES `permissoes` (`idpermissao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `usuarios` (
  `idusuarios` varchar(36) NOT NULL,
  `nome` varchar(100) DEFAULT NULL,
  `login` varchar(80) DEFAULT NULL,
  `senha` varchar(80) DEFAULT NULL,
  `ativo` tinyint(4) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  `idPerfil` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`idusuarios`),
  KEY `fkperfil_idx` (`idPerfil`),
  KEY `fk_userperfil_idx` (`idPerfil`),
  CONSTRAINT `fk_userperfil` FOREIGN KEY (`idPerfil`) REFERENCES `perfil` (`idperfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `entregas` (
  `identrega` varchar(36) NOT NULL,
  `idUsuario` varchar(36) DEFAULT NULL,
  `idDeposito` varchar(36) DEFAULT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `imagem` varchar(255) DEFAULT NULL,
  `latitude` double DEFAULT NULL,
  `longitude` double DEFAULT NULL,
  `situacao` int(11) DEFAULT NULL,
  PRIMARY KEY (`identrega`),
  KEY `fkusuario_idx` (`idUsuario`),
  KEY `fkdeposito_idx` (`idDeposito`),
  CONSTRAINT `fkdeposito` FOREIGN KEY (`idDeposito`) REFERENCES `depositos` (`iddeposito`),
  CONSTRAINT `fkusuario` FOREIGN KEY (`idUsuario`) REFERENCES `usuarios` (`idusuarios`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `mercadorias` (
  `idmercadorias` varchar(36) NOT NULL,
  `nome` varchar(100) DEFAULT NULL,
  `valor` decimal(18,2) DEFAULT NULL,
  `estoque` int(11) DEFAULT NULL,
  `imagem` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`idmercadorias`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `permissoes`
(`idpermissao`,
`modulo`,
`nome`,
`incluir`,
`ler`,
`editar`,
`deletar`)
VALUES
('5b86e6f8-c077-48f4-a9fd-0d63ce23fa8b', 'Produtos', 'Produtos', '1', '1', '1', '1');

INSERT INTO `perfil`
(`idperfil`,
`nome`,
`ativo`)
VALUES
('f8fe1905-47a7-4f46-b1dc-2717bcc70d19', 'Admistrador', '1');

INSERT INTO `permissoesperfil`
(`idPerfil`,
`idPermissao`,
`idPermissoesPerfil`)
VALUES
('f8fe1905-47a7-4f46-b1dc-2717bcc70d19', '5b86e6f8-c077-48f4-a9fd-0d63ce23fa8b', '0d654bde-d3ce-4478-b2a2-1dfdd5c66365');

INSERT INTO `usuarios`
(`idusuarios`,
`nome`,
`login`,
`senha`,
`ativo`,
`email`,
`idPerfil`)
VALUES
('6bda0319-ce49-4621-a361-d5e40a81c2a2', 'Roberto Sabino', 'sabino', 'sabino@123', '1', 'roberttosabino@gmail.com', 'f8fe1905-47a7-4f46-b1dc-2717bcc70d19');






