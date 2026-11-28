using Godot;
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Boomeranger
{
	public class Vector2JsonConverter : JsonConverter<Vector2>
	{
		public override Vector2 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return ParseVector2(reader.GetString());
		}

		public override void Write(Utf8JsonWriter writer, Vector2 value, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override Vector2 ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return ParseVector2(reader.GetString());
		}

		private static Vector2 ParseVector2(string raw)
		{
			if (string.IsNullOrWhiteSpace(raw))
			{
				throw new JsonException("vector2 string cannot be empty.");
			}

			string cleaned = raw.Trim().Trim('(', ')');
			string[] parts = cleaned.Split(',', StringSplitOptions.TrimEntries);

			if (parts.Length != 2 ||
				!float.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float x) ||
				!float.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float y))
			{
				throw new JsonException($"Invalid Vector2 format: '{raw}'.");
			}

			return new Vector2(x, y);
		}

	}
}