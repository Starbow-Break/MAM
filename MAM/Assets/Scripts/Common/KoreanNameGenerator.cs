using UnityEngine;
using System.Text;

public class KoreanNameGenerator : MonoBehaviour
{
    // 초성 (19개)
    static readonly char[] CHO = { 'ㄱ','ㄲ','ㄴ','ㄷ','ㄸ','ㄹ','ㅁ','ㅂ','ㅃ','ㅅ','ㅆ','ㅇ','ㅈ','ㅉ','ㅊ','ㅋ','ㅌ','ㅍ','ㅎ' };
    // 중성 (21개)
    static readonly char[] JUNG = { 'ㅏ','ㅐ','ㅑ','ㅒ','ㅓ','ㅔ','ㅕ','ㅖ','ㅗ','ㅘ','ㅙ','ㅚ','ㅛ','ㅜ','ㅝ','ㅞ','ㅟ','ㅠ','ㅡ','ㅢ','ㅣ' };
    // 종성 (28개, 첫번째는 없음)
    static readonly char[] JONG = { '\0','ㄱ','ㄲ','ㄳ','ㄴ','ㄵ','ㄶ','ㄷ','ㄹ','ㄺ','ㄻ','ㄼ','ㄽ','ㄾ','ㄿ','ㅀ','ㅁ','ㅂ','ㅄ','ㅅ','ㅆ','ㅇ','ㅈ','ㅊ','ㅋ','ㅌ','ㅍ','ㅎ' };

    public static string GetRandomKoreanName()
    {
        StringBuilder name = new StringBuilder();
        for (int i = 0; i < 3; i++)
        {
            int cho = Random.Range(0, CHO.Length);
            int jung = Random.Range(0, JUNG.Length);
            int jong = Random.Range(0, JONG.Length);

            int unicode = 0xAC00 + (cho * 21 * 28) + (jung * 28) + jong;
            name.Append((char)unicode);
        }
        return name.ToString();
    }
}