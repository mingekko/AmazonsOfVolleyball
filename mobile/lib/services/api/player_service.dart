part of api;

/// Itt a baseUrl-nél megszoktam adni a modulnak az URL-ét, úgy látom, hogy nálad ez a /players lesz.
@ChopperApi(baseUrl: 'players')
abstract class PlayerService extends ChopperService {
  static PlayerService create(ChopperClient client) => _$PlayerService(client);

  /// Ez egy egyszerű GET hívás, visszaad egy sima decodolt response-t majd.
  @Get()
  Future<Response> getPlayers();
}
