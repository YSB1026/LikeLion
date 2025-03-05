using System;

public class Skill
{
    public string Name; // 스킬 이름
    public int ManaCost; // 마나 소모량
    public int CoolDown; // 재사용 대기 시간 (밀리초 단위)
    public int LastUsedTime; // 마지막 사용 시간 (밀리초 단위)
    public int RemainingTime; // 남은 쿨타임 (초 단위)

    public Skill(string name, int manaCost, int coolDown)
    {
        Name = name;
        ManaCost = manaCost;
        CoolDown = coolDown * 1000; // 밀리초로 변환
        LastUsedTime = 0; // 처음엔 사용하지 않은 상태
        RemainingTime = 0; // 처음엔 쿨타임 0
    }

    // 스킬 사용 가능 여부 확인
    public bool CanUse(int playerMana, int currentTime)
    {
        // 마나 부족 확인
        if (playerMana < ManaCost)
        {
            Console.WriteLine($"마나가 부족합니다!! (필요 MP: {ManaCost})");
            return false;
        }

        // 쿨타임 확인
        if (currentTime - LastUsedTime < CoolDown)
        {
            RemainingTime = (CoolDown - (currentTime - LastUsedTime)) / 1000; // 남은 시간 계산 (초 단위로 변환)
            Console.WriteLine($"{Name} 스킬은 아직 사용할 수 없습니다. (남은 시간: {RemainingTime}초)");
            return false;
        }

        return true; // 스킬 사용 가능
    }

    // 스킬 사용
    public bool Use(ref int playerMana)
    {
        int currentTime = Environment.TickCount;

        if (!CanUse(playerMana, currentTime)) return false; // 스킬 사용 가능 여부 확인

        playerMana -= ManaCost; // 마나 차감
        LastUsedTime = currentTime; // 현재 시간을 마지막 사용 시간으로 갱신
        RemainingTime = 0; // 스킬 사용 후 남은 시간 초기화

        Console.WriteLine($"{Name} 스킬 사용! (MP - {ManaCost})");
        return true; // 스킬 사용 성공
    }
}
