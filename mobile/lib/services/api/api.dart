/// Ez ugyanaz mint a C#-ban a namespace, csak itt egy part 'filename.dart'-al megkell határozni, hogy melyik fájlok tartoznak ide - illetve
/// a cél fájlban is megkell határozni, hogy ő az api namespace-hez tartozik egy part of api;-val.
library api;

import 'package:chopper/chopper.dart';

part 'player_service.dart';
part 'api.chopper.dart';

final apiService = ChopperClient(
  /// Itt majd kikell cserélni a saját URL-re.
  baseUrl: 'https://own-api-url.io/api/v1/',
  services: [
    PlayerService.create(
      ChopperClient(),
    ),
  ],
);
