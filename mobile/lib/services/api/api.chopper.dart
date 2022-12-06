// GENERATED CODE - DO NOT MODIFY BY HAND

part of api;

// **************************************************************************
// ChopperGenerator
// **************************************************************************

// ignore_for_file: always_put_control_body_on_new_line, always_specify_types, prefer_const_declarations, unnecessary_brace_in_string_interps
class _$PlayerService extends PlayerService {
  _$PlayerService([ChopperClient? client]) {
    if (client == null) return;
    this.client = client;
  }

  @override
  final definitionType = PlayerService;

  @override
  Future<Response<dynamic>> getPlayers() {
    final String $url = 'players';
    final Request $request = Request(
      'GET',
      $url,
      client.baseUrl,
    );
    return client.send<dynamic, dynamic>($request);
  }
}
