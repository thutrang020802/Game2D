import java.util.Scanner;
public class BaiTap3 {
	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String s = "hoahauhoanvu";
		char c = "h".charAt(0); 
		int answer = 0;
		for (int i = 0; i < s.length(); i++) {
			if(s.charAt(i) == c) {
				answer ++;
			}
		}
		System.out.print(answer);
	}
}
