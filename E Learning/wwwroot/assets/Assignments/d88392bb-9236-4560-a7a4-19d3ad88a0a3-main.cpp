#include <bits/stdc++.h>
using namespace std;
vector<string> findWords(vector<string>& words) {
    string s1 = "qwertyuiop", s2 = "asdfghjkl", s3 = "zxcvbnm";
    map<char, int> mp;
    for (int i = 0; i < s1.size(); ++i) {
        mp[s1[i]] = 1;
    }
    for (int i = 0; i < s2.size(); ++i) {
        mp[s2[i]] = 2;
    }
    for (int i = 0; i < s3.size(); ++i) {
        mp[s3[i]] = 3;
    }
    vector<string>ans;
    for (int i = 0; i <words.size() ; ++i) {

        set<int> st;
        for (int j = 0; j <words[i].size(); ++j) {
            st.insert(mp[tolower(words[i][j])]);
        }
        if(st.size() ==1)
            ans.push_back(words[i]);
    }
    return ans;
}

signed main() {
    vector<string> v = {"Hello","Alaska","Dad","Peace"};
    vector<string>ans = findWords(v);
    for (int i = 0; i <ans.size()  ; ++i) {
        cout<<ans[i]<<endl;
    }
}