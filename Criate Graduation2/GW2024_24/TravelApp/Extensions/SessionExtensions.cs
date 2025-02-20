using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace TravelApp.Extensions {
    public static class SessionExtensions {
        // オブジェクトをセッションに保存
        public static void SetObjectAsJson(this ISession session, string key, object value) {
            var json = JsonSerializer.Serialize(value);
            session.SetString(key, json);
        }

        // セッションからオブジェクトを取得
        public static T GetObjectFromJson<T>(this ISession session, string key) {
            var json = session.GetString(key);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }
    }
}
